class Workflow
  def process
    you_should_do_this_first
    then_you_should_do_this
    this_will_be_done_last
  end
end

class Headhunter < Workflow

  def you_should_do_this_first
    puts("Lock the target")
  end

  def then_you_should_do_this
    puts("Bait the line")
  end

  def this_will_be_done_last
    puts("Spread the net")
  end

end

template = Headhunter.new()

template.process

# begin tests
describe Headhunter do 
 
  before do
    @headhunter = Headhunter.new()
  end

  subject { @headhunter }

  it { should respond_to(:you_should_do_this_first) }
  it { should respond_to(:then_you_should_do_this) }
  it { should respond_to(:this_will_be_done_last) }
 
  it "should call methods in order" do
    
    @headhunter.should_receive(:you_should_do_this_first).ordered
    @headhunter.should_receive(:then_you_should_do_this).ordered
    @headhunter.should_receive(:this_will_be_done_last).ordered

    @headhunter.process
  end
 
end